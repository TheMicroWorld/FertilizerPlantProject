package org.fertilizerplant.productmanagementservice.brands.services.impl;

import java.util.List;

import org.fertilizerplant.productmanagementservice.brands.models.Brand;
import org.fertilizerplant.productmanagementservice.brands.repositories.BrandRepository;
import org.fertilizerplant.productmanagementservice.brands.services.BrandService;
import org.springframework.beans.factory.annotation.Autowired;

public class DefaultBrandService implements BrandService{
	
	@Autowired
	private BrandRepository brandRepository;
	
	public List<Brand> getAllBrands()
	{
		return brandRepository.findAll();
	}
}
