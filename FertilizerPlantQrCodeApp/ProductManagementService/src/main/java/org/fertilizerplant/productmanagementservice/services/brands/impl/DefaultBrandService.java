package org.fertilizerplant.productmanagementservice.services.brands.impl;

import java.util.List;

import org.fertilizerplant.productmanagementservice.models.brands.Brand;
import org.fertilizerplant.productmanagementservice.repositories.brands.BrandRepository;
import org.fertilizerplant.productmanagementservice.services.brands.BrandService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;

@Service
@Qualifier("brandService")
@Repository
public class DefaultBrandService implements BrandService{
	
	@Autowired
	private BrandRepository brandRepository;
	
	public List<Brand> getAllBrands()
	{
		return brandRepository.findAll();
	}
}
