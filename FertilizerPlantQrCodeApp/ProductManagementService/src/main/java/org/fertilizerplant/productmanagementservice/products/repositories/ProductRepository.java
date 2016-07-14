package org.fertilizerplant.productmanagementservice.products.repositories;

import org.fertilizerplant.productmanagementservice.products.models.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.querydsl.QueryDslPredicateExecutor;

public interface ProductRepository extends JpaRepository<Product,Long>,QueryDslPredicateExecutor<Product>{
	
}
