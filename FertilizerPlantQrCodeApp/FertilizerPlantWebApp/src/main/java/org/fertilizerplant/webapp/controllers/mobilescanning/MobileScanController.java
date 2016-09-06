package org.fertilizerplant.webapp.controllers.mobilescanning;

import javax.servlet.http.HttpServletRequest;

import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.fertilizerplant.qrcodemanagementservice.models.QrCode;
import org.fertilizerplant.qrcodemanagementservice.services.qrcode.QrCodeService;
import org.fertilizerplant.usermangementservice.models.distributors.Distributor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
public class MobileScanController {
	
	public static final String SHOW_BINDING_PAGE = "pages/bindingpage/bindingpage";

	@Autowired
	private QrCodeService qrCodeService;
	
	@RequestMapping(value="/qrcode-manage/{qrocde:[\\d]+}",method=RequestMethod.GET)
	public String getBindingInformationForQrCode(ModelMap model,HttpServletRequest request)
	{
		System.out.println(request.getServletPath());
		
		QrCode qrCode = qrCodeService.getQrCodeById(request.getRequestURL().toString());
		Distributor distributor = qrCode.getDistributor();
		Product product = qrCode.getProduct();
		
		if(qrCode != null)
		{
			if(distributor == null && product == null)
			{
				product = new Product();
				distributor = new Distributor();
			}
		}
		model.addAttribute("distributor",distributor);
		model.addAttribute("product",product);
		
		return SHOW_BINDING_PAGE;
	}
}
