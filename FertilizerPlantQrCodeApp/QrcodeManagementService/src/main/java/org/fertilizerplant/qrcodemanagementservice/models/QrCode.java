package org.fertilizerplant.qrcodemanagementservice.models;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

import org.fertilizerplant.common.base.models.BaseEntity;
import org.fertilizerplant.productmanagementservice.models.products.Product;
import org.fertilizerplant.usermangementservice.models.distributors.Distributor;

@Entity
@Table(name="QrcodeSequenceNumber")
public class QrCode extends BaseEntity{
	
	@Id
	@Column(name="encodedValue",nullable = false)
	private String encodedValue;
	

	public String getEncodedValue() {
		return encodedValue;
	}

	public void setEncodedValue(String encodedValue) {
		this.encodedValue = encodedValue;
	}
	
	@ManyToOne(cascade=CascadeType.ALL)
	private Product product;
	
	@ManyToOne(cascade=CascadeType.ALL)
	private Distributor distributor;


	public Product getProduct() {
		return product;
	}

	public void setProduct(Product product) {
		this.product = product;
	}

	public Distributor getDistributor() {
		return distributor;
	}

	public void setDistributor(Distributor distributor) {
		this.distributor = distributor;
	}
}
