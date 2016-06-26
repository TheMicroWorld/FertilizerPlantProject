package org.fertilizerplant.productmanagement.brands.services.impl;

import java.util.List;

import org.fertilizerplant.productmanagement.brands.models.Brand;
import org.fertilizerplant.productmanagement.brands.repositories.BrandRepository;
import org.fertilizerplant.productmanagement.brands.services.BrandService;
import org.springframework.beans.factory.annotation.Autowired;

public class DefaultBrandService implements BrandService{
	
	@Autowired
	private BrandRepository brandRepository;
	
	public List<Brand> getAllBrands()
	{
		return brandRepository.findAll();
	}
}
