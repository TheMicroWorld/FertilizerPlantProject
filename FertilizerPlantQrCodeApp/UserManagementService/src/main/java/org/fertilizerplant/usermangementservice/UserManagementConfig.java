package org.fertilizerplant.usermangementservice;

import org.springframework.boot.orm.jpa.EntityScan;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.transaction.annotation.EnableTransactionManagement;

@Configuration
@ComponentScan
@EntityScan
@EnableJpaRepositories
@EnableTransactionManagement
public class UserManagementConfig {

}
