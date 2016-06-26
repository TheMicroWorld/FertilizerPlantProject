package org.fertilizerplant.productmanagement.repositories;

import org.fertilizerplant.productmanagement.models.Brand;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.querydsl.QueryDslPredicateExecutor;

public interface BrandRepository extends JpaRepository<Brand,Long>,QueryDslPredicateExecutor<Brand>{
	
}
