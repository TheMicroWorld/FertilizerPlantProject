package org.fertilizerplant.webapp.controllers.products;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.fertilizerplant.productmanagementservice.models.brands.Brand;
import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.fertilizerplant.productmanagementservice.services.brands.BrandService;
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
@RequestMapping(value="/product-manage")
public class ProductManagementController {
	
	public static final String ADD_PRODUCT_PAGE = "pages/product/addproduct";
	public static final String LIST_PRODUCT_PAGE = "pages/product/listproduct";
	
	@Resource
	BrandService brandService;
	
	@Resource 
	ProductService productService;
	
	public List<String> getBrands()
	{	
		List<Brand> availableBrands = brandService.getAllBrands();
		
		int size = availableBrands.size();
		List<String> brands = new ArrayList<>(size);
		
		for(int count=0;count < size;count++)
		{
			brands.add(count, availableBrands.get(count).getBrandName());
		}
		if(availableBrands.isEmpty())
		{
			System.out.println("In "+ProductManagementController.class.getName()+" Brands empty");
		}
		return brands;
	}
	
	
	@RequestMapping(value="/add-product",method=RequestMethod.GET)
	public String addProduct(ModelMap model)
	{
		ProductForm productForm = new ProductForm();
		model.addAttribute("productForm", productForm);
		model.addAttribute("brands", getBrands());

		return ADD_PRODUCT_PAGE;
	}
	
	@RequestMapping(value="/add-product",method=RequestMethod.POST)
	public String addProduct(@ModelAttribute("productForm") ProductForm productForm,BindingResult result,Model model)
	{
		
		Product product = new Product();
		Brand brand = new Brand();
		String brandName = productForm.getBrand();
		brand.setBrandName(brandName);
		
		product.setBrand(brand);
		product.setUnitName(productForm.getUnitName());
		product.setName(brandName);
		product.setQuantity(productForm.getQuantity());
		
		productService.save(product);
		
		
		//getting all the products
		List<Product> products = productService.getAllProducts();
		model.addAttribute("products", products);
		return LIST_PRODUCT_PAGE;
	}
}
