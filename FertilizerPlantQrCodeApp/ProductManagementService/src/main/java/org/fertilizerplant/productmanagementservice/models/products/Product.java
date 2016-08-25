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
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="productId")
	private Long id;
	
	/**
	 * Product name will be the name as brand name
	 */
	@Column(name="productName",unique=true)
	private String name;
	
	/**
	 * Describes the unit name of the product
	 */
	@Column(name="unitName")
	private String unitName;
	
	/**
	 * this is the stock level of this product 
	 */
	private int amount;
	
	/**
	 * this is the stock level of this product
	 */
	@OneToMany(cascade = CascadeType.ALL)
	@JoinTable(name="Product_StockLevels",
			joinColumns = @JoinColumn(name="productId"),
	        inverseJoinColumns=@JoinColumn(name="stockLevelId")
	          )
	private Set<StockLevel> stockLevels = new HashSet<StockLevel>();
	
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

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

	public int getAmount() {
		return amount;
	}

	public void setAmount(int amount) {
		this.amount = amount;
	}
}
