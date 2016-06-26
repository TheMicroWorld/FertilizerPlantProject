package org.fertilizerplant.productmanagement.services.impl;

import java.util.List;

import org.fertilizerplant.productmanagement.models.Brand;
import org.fertilizerplant.productmanagement.repositories.BrandRepository;
import org.fertilizerplant.productmanagement.services.BrandService;
import org.springframework.beans.factory.annotation.Autowired;

public class DefaultBrandService implements BrandService{
	
	@Autowired
	private BrandRepository brandRepository;
	
	public List<Brand> getAllBrands()
	{
		return brandRepository.findAll();
	}
}
