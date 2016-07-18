package org.fertilizerplant.productmanagementservice.repositories.products;

import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.querydsl.QueryDslPredicateExecutor;

public interface ProductRepository extends JpaRepository<Product,Long>,QueryDslPredicateExecutor<Product>{
	
}