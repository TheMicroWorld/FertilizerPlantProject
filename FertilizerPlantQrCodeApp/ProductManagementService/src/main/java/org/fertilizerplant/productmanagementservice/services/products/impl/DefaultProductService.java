package org.fertilizerplant.productmanagementservice.services.products.impl;

import java.util.List;
import java.util.stream.Collectors;

import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.fertilizerplant.productmanagementservice.repositories.products.ProductRepository;
import org.fertilizerplant.productmanagementservice.services.products.ProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;

@Service
@Qualifier("productService")
public class DefaultProductService implements ProductService
{
	@Autowired
	private ProductRepository productRepository;
	
	public List<Product> getAllProducts()
	{
		return productRepository.findAll();
	}
	
	public Product save(Product product)
	{
		return productRepository.save(product);
	}
	
	public List<String> getAllProductNames()
	{
		List<Product> products = getAllProducts();
		List<String> productNames = products.stream().map(p->p.getName()).collect(Collectors.toList());
		return productNames;
	}

}


