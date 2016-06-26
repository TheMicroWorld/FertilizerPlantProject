package org.fertilizerplant.productmanagement.products.services.impl;

import java.util.List;

import org.fertilizerplant.productmanagement.products.models.Product;
import org.fertilizerplant.productmanagement.products.repositories.ProductRepository;
import org.fertilizerplant.productmanagement.products.services.ProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class DefaultProductService implements ProductService
{
	@Autowired
	private ProductRepository productRepository;
	
	public List<Product> getAllProducts()
	{
		return productRepository.findAll();
	}
}
