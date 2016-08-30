package org.fertilizerplant.usermangementservice.repositories.distributors;

import org.fertilizerplant.usermangementservice.models.distributors.Distributor;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.querydsl.QueryDslPredicateExecutor;


public interface DistributorRepository extends JpaRepository<Distributor,Long>,QueryDslPredicateExecutor<Distributor>
{

}
