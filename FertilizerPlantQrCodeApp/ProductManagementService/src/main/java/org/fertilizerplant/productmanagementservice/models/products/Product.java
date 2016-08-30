package org.fertilizerplant.productmanagementservice.models.products;

import java.util.HashSet;
import java.util.Set;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import org.fertilizerplant.productmanagementservice.models.stocklevels.StockLevel;

@Entity
@Table(name="Products")
public class Product {
	
	/**
	 * Product name will be the name as brand name
	 */
	@Id
	@Column(name="productName",nullable=false)
	private String name;
	
	/**
	 * Describes the unit name of the product
	 */
	@Column(name="unitName")
	private String unitName;
	
	/**
	 * this is the stock level of this product
	 */
	@OneToMany(cascade = CascadeType.ALL)
	@JoinTable(name="Product_StockLevels",
			joinColumns = @JoinColumn(name="productId"),
	        inverseJoinColumns=@JoinColumn(name="stockLevelId")
	          )
	private Set<StockLevel> stockLevels = new HashSet<StockLevel>();

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getUnitName() {
		return unitName;
	}

	public void setUnitName(String unitName) {
		this.unitName = unitName;
	}

	public Set<StockLevel> getStockLevels() {
		return stockLevels;
	}

	public void setStockLevels(Set<StockLevel> stockLevels) {
		this.stockLevels = stockLevels;
	}

}
