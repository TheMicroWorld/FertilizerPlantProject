package org.fertilizerplant.productmanagementservice.repositories.warehouses;

import org.fertilizerplant.productmanagementservice.models.warehouses.Warehouse;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.querydsl.QueryDslPredicateExecutor;
import org.springframework.stereotype.Repository;

@Repository	
public interface WarehouseRepository extends JpaRepository<Warehouse,Long>,QueryDslPredicateExecutor<Warehouse>{

}
