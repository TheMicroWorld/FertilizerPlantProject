package org.fertilizerplant.common.address.models;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;

@Entity
public class Province {
	
	@Id
	@Column(name="provinceId")
	private Long id;
	
	private String code;
	
	private String name;
}
