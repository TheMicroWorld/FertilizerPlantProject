package org.fertilizerplant.qrcodemanagementservice.services.qrcode.impl;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.fertilizerplant.productmanagementservice.services.products.ProductService;
import org.fertilizerplant.qrcodemanagementservice.models.QQrCode;
import org.fertilizerplant.qrcodemanagementservice.models.QrCode;
import org.fertilizerplant.qrcodemanagementservice.repositories.qrcode.QrCodeRepository;
import org.fertilizerplant.qrcodemanagementservice.services.qrcode.QrCodeService;
import org.fertilizerplant.qrcodemanagementservice.synchronization.QrCodeSyncDataRecv;
import org.fertilizerplant.usermangementservice.models.distributors.Distributor;
import org.fertilizerplant.usermangementservice.services.distributors.DistributorService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import com.mysema.query.types.Predicate;

@Service
@Qualifier("qrcodeService")
public class DefaultQrCodeService implements QrCodeService {
	
	@Autowired
	private QrCodeRepository qrCodeRepository;
	
	@Autowired
	private ProductService productService;
	
	@Autowired
	private DistributorService distributorService;

	public List<QrCode> getAllQrCodes() {
		return qrCodeRepository.findAll();
	}

	public QrCode save(QrCode qrCode) {
		return qrCodeRepository.save(qrCode);
	}

	public List<String> getAllQrCodeValues() {
		List<QrCode> qrcodes = getAllQrCodes();
		List<String> qrcodeValues = qrcodes.stream().map(q -> q.getEncodedValue()).collect(Collectors.toList());
		return qrcodeValues;
	}

	@Transactional 
	public void generateQrCodes(int number,String encodedValueWebrootPrefix)
    {
    	long alreadyUsed = qrCodeRepository.count();
    	List<QrCode> qrcodes = new ArrayList<QrCode>();
    	for(int i=0 ; i < number; i++)
    	{
    		QrCode qrcode = new QrCode();
    		qrcodes.add(qrcode);
        	String encodedValue = encodedValueWebrootPrefix + "/" + alreadyUsed++;
    		qrcode.setEncodedValue(encodedValue);
    	}
    	qrCodeRepository.bulkSave(qrcodes);
    }

	@Transactional
	public void updateQrCodesSyncStatusAndBindingInfo(List<QrCodeSyncDataRecv> dataReceived) {
		List<QrCode> qrCodes = new ArrayList<QrCode>();
		for(QrCodeSyncDataRecv data : dataReceived)
		{
			String productName = data.getProductId();
			String distributorName = data.getDistributorId();
			Product product = null;
			Distributor distributor = null;
			
			if(productName != null)
			{
				product = productService.findProductById(productName);
			}
			
			if(distributorName != null)
			{
				distributor = distributorService.findDistributorById(distributorName);
			}
			
			QrCode qrCode = qrCodeRepository.findOne(data.getId());
			qrCode.setProduct(product);
			qrCode.setDistributor(distributor);
			qrCode.setSyncStatus(data.isSyncStatus());
			qrCodes.add(qrCode);
		}
		qrCodeRepository.bulkSave(qrCodes);
	}

	public List<QrCode> getAllUnSynchedQrCodes() {
		QQrCode qrcode = QQrCode.qrCode;
		Predicate qrcodeUnsynched = qrcode.syncStatus.eq(false);
		return (List<QrCode>) qrCodeRepository.findAll(qrcodeUnsynched);
	}

	@Override
	public QrCode getQrCodeById(String qrCodeId) {
		
		return qrCodeRepository.findOne(qrCodeId);
	}

}
