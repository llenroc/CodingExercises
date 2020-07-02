package org.practice;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

/**
 * Unit test for Screen Class.
 */
public class ScreenTests {
    @Test
    public void google_getScoreTests() throws Exception {
        // Arrange

        // Act
        int[] result = Screen.google_getScore("girls", "lakes");
        
        // Assert
        assertEquals( result[0], 2 );
        assertEquals( result[1], 1 );
    }
}