package org.fertilizerplant.webapp.controllers.distributors;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/user-manage")
public class DistributorManagementController {
	
	public static final String ADD_DISTRIBUTOR_PAGE = "pages/distributor/adddistributor";
	
	@RequestMapping("/add-distributor")
	public String generateQrCode()
	{
		return ADD_DISTRIBUTOR_PAGE;
	}

}
