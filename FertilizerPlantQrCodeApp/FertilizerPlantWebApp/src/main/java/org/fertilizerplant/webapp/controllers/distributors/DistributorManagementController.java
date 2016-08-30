package org.fertilizerplant.webapp.controllers.distributors;

import java.util.List;

import org.fertilizerplant.usermangementservice.models.distributors.Distributor;
import org.fertilizerplant.usermangementservice.services.distributors.DistributorService;
import org.fertilizerplant.webapp.controllers.users.UserManagementController;
import org.fertilizerplant.webapp.forms.distributors.DistributorForm;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping("/distributor-manage")
public class DistributorManagementController extends UserManagementController{
	
	public static final String ADD_DISTRIBUTOR_PAGE = "pages/distributor/adddistributor";
	public static final String LIST_DISTRIBUTOR_PAGE = "pages/distributor/listdistributor";
	
	@Autowired
	private DistributorService distributorService;
	
	
	@RequestMapping("/add-distributor")
	public String generateQrCode(ModelMap model)
	{
		DistributorForm distributorForm = new DistributorForm();
		model.addAttribute("distributorForm", distributorForm);
		model.addAttribute("distributorNames", distributorService.getAllUserNames());
		return ADD_DISTRIBUTOR_PAGE;
	}
	
	@RequestMapping(value = "/add-distributor", method = RequestMethod.POST)
	public String addDistributor(@ModelAttribute("distributorForm") DistributorForm distributorForm, BindingResult result,
			Model model) {

		Distributor distributor = new Distributor();
		distributor.setName(distributorForm.getName());

		distributor.setAddress(distributorForm.getAddress());
		distributor.setPhoneNumber(distributorForm.getPhoneNumber());

		distributorService.save(distributor);

		// getting all the Distributors
		List<Distributor> distributors = distributorService.getAllDistributors();
		model.addAttribute("distributors", distributors);
		return LIST_DISTRIBUTOR_PAGE;
	}

	@RequestMapping(value = "list-distributor", method = RequestMethod.GET)
	public String listDistributor(ModelMap model) {
		// getting all the Distributors
		List<Distributor> Distributors = distributorService.getAllDistributors();
		model.addAttribute("distributors", Distributors);
		return LIST_DISTRIBUTOR_PAGE;
	}
}
