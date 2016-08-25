package org.fertilizerplant.webapp.forms.products;

import java.util.List;

public class ProductForm {
	private String productName;

	private String unitName;
	
	private int quantity;

	public String getUnitName() {
		return unitName;
	}

	public void setUnitName(String unitName) {
		this.unitName = unitName;
	}

	public int getQuantity() {
		return quantity;
	}

	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}	
}
