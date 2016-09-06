package org.fertilizerplant.productmanagementservice.models.warehouses;

import java.util.HashSet;
import java.util.Set;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.JoinTable;
import javax.persistence.OneToMany;

import org.fertilizerplant.productmanagementservice.models.stocklevels.StockLevel;
import org.hibernate.annotations.Type;

@Entity
public class Warehouse {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="warehouseId")
	private Long id;
	
	/**
	 * address of this warehouse
	 */
	private String address;
	
	/**
	 * stock levels of this warehouse
	 */
	@OneToMany(cascade = CascadeType.ALL,fetch=FetchType.LAZY)
	@JoinTable(name="Warehouse_StockLevels",
			joinColumns = @JoinColumn(name="warehouseId"),
	        inverseJoinColumns=@JoinColumn(name="stockLevelId")
	          )
	private Set<StockLevel> stockLevels = new HashSet<StockLevel>();

	/**
	 * indicate if this is the default warehouse
	 */
	@Type(type="yes_no")
	private boolean defaultWarehouse;
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public Set<StockLevel> getStockLevels() {
		return stockLevels;
	}

	public void setStockLevels(Set<StockLevel> stockLevels) {
		this.stockLevels = stockLevels;
	}
}
