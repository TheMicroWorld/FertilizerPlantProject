package org.fertilizerplant.usermangementservice.services.users;

import java.util.List;

import org.fertilizerplant.usermangementservice.models.users.User;

public interface UserService {
	
	List<User> getAllUsers();
	User save(User user);
	List<String> getAllUserNames();
}
