package org.fertilizerplant.webapp.controllers.products;

import java.util.List;

import javax.annotation.Resource;

import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.fertilizerplant.productmanagementservice.services.products.ProductService;
import org.fertilizerplant.webapp.forms.products.ProductForm;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
@RequestMapping(value = "/product-manage")
public class ProductManagementController {

	public static final String ADD_PRODUCT_PAGE = "pages/product/addproduct";
	public static final String LIST_PRODUCT_PAGE = "pages/product/listproduct";

	private static final String ADD_PRODUCT_LINK = "/add-product";
	private static final String LIST_PRODUCT_LINK = "/list-product";
	private static final String REDIRECT_LIST_PRODUCT_LINK = "/product-manage/list-product";

	
	@Resource
	ProductService productService;


	@RequestMapping(value = ADD_PRODUCT_LINK, method = RequestMethod.GET)
	public String addProduct(ModelMap model) {
		ProductForm productForm = new ProductForm();
		model.addAttribute("productForm", productForm);
		model.addAttribute("productNames", productService.getAllProductNames());

		return ADD_PRODUCT_PAGE;
	}

	@RequestMapping(value = ADD_PRODUCT_LINK, method = RequestMethod.POST)
	public String addProduct(@ModelAttribute("productForm") ProductForm productForm, BindingResult result,
			Model model) {

		Product product = new Product();
		product.setProductName(productForm.getProductName());

		product.setUnitName(productForm.getUnitName());
		product.setBrandName(productForm.getBrandName());
		product.setSpecification(productForm.getProductSpecification());
		
		productService.save(product);

		return "redirect:" + REDIRECT_LIST_PRODUCT_LINK;
	}

	@RequestMapping(value = LIST_PRODUCT_LINK, method = RequestMethod.GET)
	public String listProduct(ModelMap model) {
		// getting all the products
		List<Product> products = productService.getAllProducts();
		model.addAttribute("products", products);
		return LIST_PRODUCT_PAGE;
	}
}
