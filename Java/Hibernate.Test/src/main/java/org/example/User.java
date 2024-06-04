package org.example;

import jakarta.persistence.*;

@Entity
@Table(name = "Users")
public class User {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private int id;
    private String name;
    private char gender;
    private boolean isActive;
    private float age;

    public User(){

    }

    public User(String name, char gender, boolean isActive, float age) {
        this.name = name;
        this.gender = gender;
        this.isActive = isActive;
        this.age = age;
    }

    public int GetId() { return id; }

    public String GetName() { return name; }

    public void SetName(String name)
    {
        this.name = name;
    }

    public char GetGender() { return gender; }

    public void SetGender(char gender)
    {
        this.gender = gender;
    }

    public boolean GetIsActive() { return isActive; }

    public void SetIsActive(boolean isActive)
    {
        this.isActive = isActive;
    }

    public float GetAge() { return age; }

    public void SetName(float age)
    {
        this.age = age;
    }
}