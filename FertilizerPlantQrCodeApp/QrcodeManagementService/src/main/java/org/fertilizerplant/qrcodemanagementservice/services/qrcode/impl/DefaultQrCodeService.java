package org.fertilizerplant.qrcodemanagementservice.services.qrcode.impl;

import java.util.List;

import org.fertilizerplant.qrcodemanagementservice.models.QrCode;
import org.fertilizerplant.qrcodemanagementservice.repositories.qrcode.QrCodeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;

@Service
@Qualifier("qrCodeService")
public class DefaultQrCodeService {
	
	@Autowired
	QrCodeRepository qrCodeRepository;
	
	public List<QrCode> getAllQrCodes()
	{
		return qrCodeRepository.findAll();
	}
    public QrCode save(QrCode qrCode)
    {
    	return qrCodeRepository.save(qrCode);
    }
}
