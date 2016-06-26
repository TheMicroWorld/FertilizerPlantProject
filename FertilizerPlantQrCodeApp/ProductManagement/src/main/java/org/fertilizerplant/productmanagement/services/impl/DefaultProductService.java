package org.fertilizerplant.productmanagement.services.impl;

import java.util.List;

import org.fertilizerplant.productmanagement.models.Product;
import org.fertilizerplant.productmanagement.repositories.ProductRepository;
import org.fertilizerplant.productmanagement.services.ProductService;
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
