package org.fertilizerplant.usermangementservice.repositories.users;

import org.fertilizerplant.usermangementservice.models.users.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.querydsl.QueryDslPredicateExecutor;
import org.springframework.stereotype.Repository;

@Repository
public interface UserRepository extends JpaRepository<User,Long>,QueryDslPredicateExecutor<User>
{	
}
