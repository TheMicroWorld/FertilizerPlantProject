package org.fertilizerplant.productmanagement.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="QrcodeSequenceNumber")
public class QrCodeSequenceNumber {
	
	@Id
	@Column(name="qrCodeSequenceNumberId")
	private Long id;
	
	private String encodedValue;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getEncodedValue() {
		return encodedValue;
	}

	public void setEncodedValue(String encodedValue) {
		this.encodedValue = encodedValue;
	}
	
}
