package org.fertilizerplant.webapp.controllers.qrcode;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping(value="/qrcode-manage")
public class QrCodeManageController {
	
	public static final String GENERATE_QRCODE_PAGE = "pages/qrcode/generateqrcode";
	
	@RequestMapping(value="/generate-qrcode",method=RequestMethod.GET)
	public String generateQrCode()
	{
		return GENERATE_QRCODE_PAGE;
	}
	
	@RequestMapping(value="/generate-qrcode",method=RequestMethod.POST)
	public String generateQrCode(Model model)
	{
		return GENERATE_QRCODE_PAGE;
	}
	
}
