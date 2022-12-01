package main

import (
	"testing"
)

func TestHello(t *testing.T) {
	for _, c := range []struct {
		in, want string
	}{
		{"Thomas", "Hello Thomas"},
		{"Simon", "Hello Simon"},
	} {
		got := Hello(c.in)
		if got != c.want {
			t.Errorf("Error")
		}
	}
}
