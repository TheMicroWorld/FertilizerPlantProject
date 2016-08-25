package org.fertilizerplant.productmanagementservice.models.stocklevels;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToOne;

import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.fertilizerplant.productmanagementservice.models.warehouses.Warehouse;

@Entity
public class StockLevel {
	
	@Id
	@Column(name="stockLevelId")
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private Long id;
	
	/**
	 * this is the stock level of the product
	 */
	private int amount;
	/**
	 * one stock level correspond to one product
	 */
	@OneToOne(mappedBy="stockLevels")
	private Product product;
	
	@OneToOne(mappedBy="stockLevels")
	private Warehouse warehouses;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public int getAmount() {
		return amount;
	}

	public void setAmount(int amount) {
		this.amount = amount;
	}

	public Product getProduct() {
		return product;
	}

	public void setProduct(Product product) {
		this.product = product;
	}

	public Warehouse getWarehouses() {
		return warehouses;
	}

	public void setWarehouses(Warehouse warehouses) {
		this.warehouses = warehouses;
	}
	
	
}
