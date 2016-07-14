package org.fertilizerplant.productmanagementservice.products.services.impl;

import java.util.List;

import org.fertilizerplant.productmanagementservice.products.models.Product;
import org.fertilizerplant.productmanagementservice.products.repositories.ProductRepository;
import org.fertilizerplant.productmanagementservice.products.services.ProductService;
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
