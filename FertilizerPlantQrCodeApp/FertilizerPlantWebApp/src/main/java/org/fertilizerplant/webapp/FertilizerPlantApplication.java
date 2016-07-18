package org.fertilizerplant.webapp;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.MessageSourceAutoConfiguration;
import org.springframework.boot.autoconfigure.jdbc.DataSourceAutoConfiguration;
import org.springframework.boot.autoconfigure.jdbc.DataSourceTransactionManagerAutoConfiguration;
import org.springframework.boot.autoconfigure.orm.jpa.HibernateJpaAutoConfiguration;
import org.springframework.boot.autoconfigure.thymeleaf.ThymeleafAutoConfiguration;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;

@Configuration
@EnableAutoConfiguration(exclude ={ ThymeleafAutoConfiguration.class,
		MessageSourceAutoConfiguration.class})
@ComponentScan(basePackages = { "org.fertilizerplant" })
@PropertySource(value = { "classpath:application.properties", "log4j.properties" })
public class FertilizerPlantApplication {

	public static void main(String[] args) {
		SpringApplication.run(FertilizerPlantApplication.class, args);
	}
}
