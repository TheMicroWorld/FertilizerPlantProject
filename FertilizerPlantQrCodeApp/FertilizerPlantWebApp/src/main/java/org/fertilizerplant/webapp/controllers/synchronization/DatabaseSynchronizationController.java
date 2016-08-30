package org.fertilizerplant.webapp.controllers.synchronization;

import java.util.List;

import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.fertilizerplant.productmanagementservice.services.products.ProductService;
import org.fertilizerplant.qrcodemanagementservice.models.QrCode;
import org.fertilizerplant.qrcodemanagementservice.services.qrcode.QrCodeService;
import org.fertilizerplant.usermangementservice.models.distributors.Distributor;
import org.fertilizerplant.usermangementservice.services.distributors.DistributorService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
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
	public @ResponseBody List<Product> synchronizeProducts()
	{
		List<Product> products = productService.getAllProducts();
		return products;
	}
	
	@RequestMapping(value="/distributors",method=RequestMethod.GET)
	public @ResponseBody List<Distributor> synchronizeDistributors()
	{
		List<Distributor> distributors = distributorService.getAllDistributors();
		return distributors;
	}
	
	@RequestMapping(value="/qrcodes",method=RequestMethod.GET)
	public @ResponseBody List<QrCode> synchronizeQrCodes()
	{
		List<QrCode> qrcodes = qrcodeService.getAllQrCodes();
		return qrcodes;
	}
}
