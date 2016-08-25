package org.fertilizerplant.usermangementservice.models.distributors;

import javax.persistence.DiscriminatorValue;
import javax.persistence.Entity;
import javax.persistence.Table;

import org.fertilizerplant.usermangementservice.models.users.User;

@Entity
@Table(name="Users")
@DiscriminatorValue("Distributor")
public class Distributor extends User {
	
}
