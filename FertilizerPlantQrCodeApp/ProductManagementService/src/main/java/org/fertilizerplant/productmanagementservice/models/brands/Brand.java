package org.fertilizerplant.productmanagementservice.models.brands;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="Brands")
public class Brand {
	
	@Id
	@Column(name="brandId")
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private Long id;
	
	
	private String brandName;
	
	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getBrandName() {
		return brandName;
	}

	public void setBrandName(String brandName) {
		this.brandName = brandName;
	}
}
