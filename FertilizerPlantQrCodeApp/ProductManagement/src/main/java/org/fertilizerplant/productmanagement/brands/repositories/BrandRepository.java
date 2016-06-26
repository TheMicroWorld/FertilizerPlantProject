package org.fertilizerplant.productmanagement.brands.repositories;

import org.fertilizerplant.productmanagement.brands.models.Brand;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.querydsl.QueryDslPredicateExecutor;

public interface BrandRepository extends JpaRepository<Brand,Long>,QueryDslPredicateExecutor<Brand>{
	
}
