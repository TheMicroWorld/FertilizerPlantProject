package org.fertilizerplant.webapp.forms.products;

public class ProductForm {
	private String productName;

	private String unitName;
	
	/**
	 * product brand
	 */
	private String brandName;
	
	/**
	 * product specification
	 */
	private String productSpecification;
	public String getUnitName() {
		return unitName;
	}

	public void setUnitName(String unitName) {
		this.unitName = unitName;
	}

	public String getProductName() {
		return productName;
	}

	public void setProductName(String productName) {
		this.productName = productName;
	}

	public String getBrandName() {
		return brandName;
	}

	public void setBrandName(String brandName) {
		this.brandName = brandName;
	}

	public String getProductSpecification() {
		return productSpecification;
	}

	public void setProductSpecification(String productSpecification) {
		this.productSpecification = productSpecification;
	}
}
