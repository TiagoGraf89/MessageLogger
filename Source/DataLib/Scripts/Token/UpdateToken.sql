update [token] 
	set expireson = @expireson
where token = @token;
