package org.fertilizerplant.webapp.configs.web;


import java.util.Locale;

import org.springframework.context.MessageSource;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.support.ReloadableResourceBundleMessageSource;
import org.springframework.validation.Validator;
import org.springframework.validation.beanvalidation.LocalValidatorFactoryBean;
import org.springframework.web.servlet.LocaleResolver;
import org.springframework.web.servlet.config.annotation.InterceptorRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;
import org.springframework.web.servlet.i18n.LocaleChangeInterceptor;
import org.springframework.web.servlet.i18n.SessionLocaleResolver;

@Configuration
public class WebConfig extends WebMvcConfigurerAdapter {
	
	
	@Bean
	public MessageSource messageSource() {

	    ReloadableResourceBundleMessageSource messageSource = new ReloadableResourceBundleMessageSource();
	    messageSource.setBasenames("classpath:/messages/messages");
	    // if true, the key of the message will be displayed if the key is not
	    // found, instead of throwing a NoSuchMessageException
	    messageSource.setUseCodeAsDefaultMessage(false);
	    messageSource.setFallbackToSystemLocale(true);
	    messageSource.setDefaultEncoding("UTF-8");
	    // # -1 : never reload, 0 always reload
	    messageSource.setCacheSeconds(0);

	    return messageSource;
	}
	
	@Override
	public Validator getValidator()  {
	    LocalValidatorFactoryBean validator = new LocalValidatorFactoryBean();
	    validator.setValidationMessageSource(messageSource());
	    return validator;
	}
	
	@Bean
	public LocaleResolver localeResolver() {
	    SessionLocaleResolver slr = new SessionLocaleResolver();
	    slr.setDefaultLocale(Locale.CHINA);
	    return slr;
	}
	
	@Bean
	public LocaleChangeInterceptor localeChangeInterceptor() {
	    LocaleChangeInterceptor lci = new LocaleChangeInterceptor();
	    lci.setParamName("lang");
	    return lci;
	}
	
    @Override
    public void addInterceptors(InterceptorRegistry registry) {
        registry.addInterceptor(localeChangeInterceptor());
    }
}
