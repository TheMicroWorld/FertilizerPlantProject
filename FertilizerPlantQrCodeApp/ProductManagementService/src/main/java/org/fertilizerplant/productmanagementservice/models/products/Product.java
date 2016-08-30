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
	 * Product name is the name of the product,this should be unique.One brand
	 * can have many product names
	 */
	@Id
	@Column(name="productName",nullable=false)
	private String name;
	
	/**
	 * product brand name
	 */
	@Column(name="productBrandName")
	private String brandName;
	
	/**
	 * Describes the unit name of the product
	 */
	@Column(name="unitName")
	private String unitName;
	
	@Column(name="specification")
	private String specification;
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

	public String getBrandName() {
		return brandName;
	}

	public void setBrandName(String brandName) {
		this.brandName = brandName;
	}

	public String getSpecification() {
		return specification;
	}

	public void setSpecification(String specification) {
		this.specification = specification;
	}
	
	
}
