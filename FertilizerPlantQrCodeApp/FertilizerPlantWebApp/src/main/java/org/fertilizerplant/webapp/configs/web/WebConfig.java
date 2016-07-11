package org.fertilizerplant.webapp.configs.web;

import org.springframework.context.MessageSource;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.support.ResourceBundleMessageSource;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;

@Configuration
public class WebConfig extends WebMvcConfigurerAdapter {
	
	@Bean
	public MessageSource messageSource() {

	    ResourceBundleMessageSource messageSource = new ResourceBundleMessageSource();
	    messageSource.setBasenames("classpath:messages/messages");
	    // if true, the key of the message will be displayed if the key is not
	    // found, instead of throwing a NoSuchMessageException
	    messageSource.setFallbackToSystemLocale(true);
	    messageSource.setDefaultEncoding("UTF-8");
	    // # -1 : never reload, 0 always reload
	    messageSource.setCacheSeconds(0);

	    return messageSource;
	}
}
