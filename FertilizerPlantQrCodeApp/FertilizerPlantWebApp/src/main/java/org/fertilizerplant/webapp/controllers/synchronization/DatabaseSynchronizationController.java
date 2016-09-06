package org.fertilizerplant.webapp.controllers.synchronization;

import java.util.List;

import org.fertilizerplant.common.synchronization.download.BaseSyncDataRecv;
import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.fertilizerplant.productmanagementservice.services.products.ProductService;
import org.fertilizerplant.qrcodemanagementservice.models.QrCode;
import org.fertilizerplant.qrcodemanagementservice.services.qrcode.QrCodeService;
import org.fertilizerplant.qrcodemanagementservice.synchronization.QrCodeSyncDataRecv;
import org.fertilizerplant.usermangementservice.models.distributors.Distributor;
import org.fertilizerplant.usermangementservice.services.distributors.DistributorService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

@Controller
@RequestMapping(value="/synchronization")
public class DatabaseSynchronizationController {
	
	@Autowired
	private ProductService productService;
	
	@Autowired
	private QrCodeService qrcodeService;
	
	@Autowired
	private DistributorService distributorService;
	
	@RequestMapping(value="/products",method=RequestMethod.GET)
	public @ResponseBody List<Product> syncProductsToClient()
	{
		List<Product> products = productService.getAllUnSynchedProducts();
		return products;
	}
	
	@RequestMapping(value="/products",method=RequestMethod.POST)
	public ResponseEntity updateProductsSyncStatus(@RequestBody List<BaseSyncDataRecv> dataReceived)
	{
		productService.updateProductsSyncStatus(dataReceived);
		return ResponseEntity.status(HttpStatus.OK).body("Succeed");
	}
	
	@RequestMapping(value="/distributors",method=RequestMethod.GET)
	public @ResponseBody List<Distributor> synchronizeDistributorToClient()
	{
		List<Distributor> distributors = distributorService.getAllUnSynchedDistributor();
		return distributors;
	}
	
	@RequestMapping(value="/distributors",method=RequestMethod.POST)
	public ResponseEntity updateDistributorsSyncStatus(@RequestBody List<BaseSyncDataRecv> dataReceived)
	{
		distributorService.updateDistributorsSyncStatus(dataReceived);
		return ResponseEntity.status(HttpStatus.OK).body("Succeed");
	}
	
	@RequestMapping(value="/qrcodes",method=RequestMethod.GET)
	public @ResponseBody List<QrCode> synchronizeQrCodesToClient()
	{
		List<QrCode> qrcodes = qrcodeService.getAllUnSynchedQrCodes();
		return qrcodes;
	}
	
	@RequestMapping(value="/qrcodes",method=RequestMethod.POST)
	public ResponseEntity updateQrCodesSyncStatus(@RequestBody List<QrCodeSyncDataRecv> dataReceived)
	{
		
		qrcodeService.updateQrCodesSyncStatusAndBindingInfo(dataReceived);
		return ResponseEntity.status(HttpStatus.OK).body("Succeed");
	}
}
