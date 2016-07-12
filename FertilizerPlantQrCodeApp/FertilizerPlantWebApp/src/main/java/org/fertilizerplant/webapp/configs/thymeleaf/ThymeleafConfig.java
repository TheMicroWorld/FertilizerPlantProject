package org.fertilizerplant.webapp.configs.thymeleaf;

import java.util.HashSet;
import java.util.Set;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.ViewResolver;
import org.thymeleaf.dialect.IDialect;
import org.thymeleaf.extras.springsecurity4.dialect.SpringSecurityDialect;
import org.thymeleaf.spring4.SpringTemplateEngine;
import org.thymeleaf.spring4.templateresolver.SpringResourceTemplateResolver;
import org.thymeleaf.spring4.view.ThymeleafViewResolver;

@Configuration
public class ThymeleafConfig {
	
	@Bean
	public SpringResourceTemplateResolver templateResolver() {
		SpringResourceTemplateResolver resolver = new SpringResourceTemplateResolver();
	    resolver.setPrefix("classpath:/templates/");
	    resolver.setSuffix(".html");

	    // must use Legacy HTML5 as the template, otherwise Handlebars will not parse!
	    //
	    // this should hopefully be fixed in Thymeleaf 3.0
	    resolver.setCharacterEncoding("utf-8");
	    resolver.setTemplateMode("HTML5");
	    resolver.setCacheable(false);
	    return resolver;
	}

	@Bean
	public SpringTemplateEngine templateEngine() {
	    SpringTemplateEngine engine = new SpringTemplateEngine();
	    engine.setTemplateResolver(templateResolver());

	    // Add Spring security
	    Set<IDialect> dialects = new HashSet<IDialect>();
	    engine.setAdditionalDialects(dialects);
	    engine.addDialect(new SpringSecurityDialect());
	    return engine;
	}

	@Bean
	public ViewResolver viewResolver() {
	    ThymeleafViewResolver viewResolver = new ThymeleafViewResolver();
	    viewResolver.setTemplateEngine(templateEngine());
	    viewResolver.setCharacterEncoding("utf-8");
	    viewResolver.setOrder(1);
	    viewResolver.setViewNames(new String[]{"*"});
	    viewResolver.setCache(false);
	    return viewResolver;
	}
}
