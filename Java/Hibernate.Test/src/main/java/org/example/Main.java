package org.example;

import org.hibernate.Session;
import org.hibernate.Transaction;

import java.util.List;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        //TIP Press <shortcut actionId="ShowIntentionActions"/> with your caret at the highlighted text
        // to see how IntelliJ IDEA suggests fixing it.
        System.out.printf("Hello and welcome!");
        Data data= new Data();

        for (int i = 1; i <= 5; i++)
        {
            User user = new User("name"+i,'M',i%2==0,i*20);
            data.GetUsers().add(user);
            System.out.println("i = " + i);
        }

        Transaction transaction = null;
        try (Session session = HibernateUtil.getSessionFactory().openSession()) {
            // start a transaction
            transaction = session.beginTransaction();
            // save the student objects

            for (User u : data.GetUsers()) {
                session.save(u);
            }

            // commit transaction
            transaction.commit();
            session.close();
        }
        catch (Exception e) {
            if (transaction != null) {
                transaction.rollback();
            }
            e.printStackTrace();
        }

        try (Session session = HibernateUtil.getSessionFactory().openSession()) {
            List<User> users = session.createQuery("from User", User.class).list();
            users.forEach(s -> System.out.println(s.GetName()));
        }
        catch (Exception e) {
            if (transaction != null) {
                transaction.rollback();
            }
            e.printStackTrace();
        }
    }
}