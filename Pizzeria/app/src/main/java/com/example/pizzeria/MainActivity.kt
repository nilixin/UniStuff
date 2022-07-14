package com.example.pizzeria

import android.os.Bundle
import android.widget.ImageView
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.navigation.findNavController
import androidx.navigation.ui.setupWithNavController
import com.google.android.material.bottomnavigation.BottomNavigationView

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        // Setup navigation view with navigation controller
        val bottomNavigationView = findViewById<BottomNavigationView>(R.id.bottomNavigationView)
        val navigationController = findNavController(R.id.fragment)
        bottomNavigationView.setupWithNavController(navigationController)

        // Logo clicked
        val ivLogo: ImageView = findViewById(R.id.logo)
        ivLogo.setOnClickListener {
            Toast.makeText(this@MainActivity, "Logo click", Toast.LENGTH_SHORT).show()
        }
    }
}