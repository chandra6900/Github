package org.example;

import java.util.ArrayList;

public class Data {
    private ArrayList<User> users = new ArrayList<User>();

    public ArrayList<User> GetUsers() { return users; }

    public void SetGender(ArrayList<User> users)
    {
        this.users = users;
    }
}
