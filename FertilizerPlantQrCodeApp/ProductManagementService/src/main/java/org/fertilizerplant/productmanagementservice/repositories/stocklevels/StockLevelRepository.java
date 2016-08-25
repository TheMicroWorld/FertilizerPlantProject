package org.fertilizerplant.productmanagementservice.repositories.stocklevels;

import org.fertilizerplant.productmanagementservice.models.stocklevels.StockLevel;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.querydsl.QueryDslPredicateExecutor;
import org.springframework.stereotype.Repository;

@Repository	
public interface StockLevelRepository extends JpaRepository<StockLevel,Long>,QueryDslPredicateExecutor<StockLevel> {

}
