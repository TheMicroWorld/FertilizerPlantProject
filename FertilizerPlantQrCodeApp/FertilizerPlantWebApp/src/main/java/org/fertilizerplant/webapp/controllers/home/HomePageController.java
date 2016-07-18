package org.fertilizerplant.webapp.controllers.home;

import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;

@Controller
@RequestMapping(value="/")
public class HomePageController {
	public static final String REDIRECT_ADD_PRODUCT_URL = "redirect:/product-manage/add-product";
	@RequestMapping(method = RequestMethod.GET)
	public String redirectToAddProductPage(ModelMap model)
	{
		return REDIRECT_ADD_PRODUCT_URL;
	}

}
