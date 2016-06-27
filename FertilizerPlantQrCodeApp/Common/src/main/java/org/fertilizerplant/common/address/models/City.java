package org.fertilizerplant.common.address.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class City {
	
	@Id
	@Column(name="cityId")
	private Long id;
	
	private String code;
	
	private String name;
}
