package org.fertilizerplant.webapp.controllers.qrcode;

import java.util.List;

import javax.servlet.http.HttpServletRequest;

import org.fertilizerplant.qrcodemanagementservice.models.QrCode;
import org.fertilizerplant.qrcodemanagementservice.services.qrcode.QrCodeService;
import org.fertilizerplant.webapp.forms.qrcodes.QrCodeForm;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping(value="/qrcode-manage")
public class QrCodeManagementController {
	
	public static final String GENERATE_QRCODE_PAGE = "pages/qrcode/generateqrcode";
	public static final String LIST_QRCODE_PAGE = "pages/qrcode/listqrcode";
	
	public static final String SCANNED_QRCODE_PAGE = "pages/qrcode/scannedqrcodepage";
	public static final String SCANNED_URL_REQUEST_MAPPING_PATH = "/qrcode-manage"; 
	
	private static final String ADD_QRCODE_LINK = "/generate-qrcode";
	private static final String LIST_QRCODE_LINK = "/list-qrcode";
	private static final String REDIRECT_LIST_PRODUCT_LINK = "redirect:/qrcode-manage/list-qrcode";
	
	@Autowired
	private QrCodeService qrcodeService;
	
	@RequestMapping(value=ADD_QRCODE_LINK,method=RequestMethod.GET)
	public String generateQrCode(ModelMap model)
	{
		QrCodeForm qrcodeForm = new QrCodeForm();
		model.addAttribute("qrcodeForm", qrcodeForm);
		model.addAttribute("qrcodeNames", qrcodeService.getAllQrCodeValues());
		return GENERATE_QRCODE_PAGE;
	}
	
	@RequestMapping(value = ADD_QRCODE_LINK, method = RequestMethod.POST)
	public String addProduct(@ModelAttribute("qrCodeForm") QrCodeForm qrCodeForm, BindingResult result,Model model,HttpServletRequest request)
	{
		QrCode qrcode = new QrCode();
		String encodedWebRootPrefix = request.getRequestURL().toString().replace(request.getRequestURI()
				,request.getContextPath()) + SCANNED_URL_REQUEST_MAPPING_PATH;
		
		qrcodeService.generateQrCodes(qrCodeForm.getCount(),encodedWebRootPrefix);
		
		return REDIRECT_LIST_PRODUCT_LINK;
	}

	
	@RequestMapping(value=LIST_QRCODE_LINK,method=RequestMethod.GET)
	public String listQrCode(ModelMap model)
	{
		// getting all the qrcodes
		List<String> qrcodes = qrcodeService.getAllQrCodeValues();
		model.addAttribute("qrcodes", qrcodes);
		return LIST_QRCODE_PAGE;
	}
}
