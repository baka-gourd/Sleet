<template>
  <nav class="flex p-3 m-1 justify-between md:mr-24 md:ml-24">
    <div class="flex">
      <router-link class="mx-2" to="/">
        <img src="https://i.loli.net/2018/07/01/5b37ad8817cb2.png" alt="icon" />
      </router-link>
      <p class="mx-2 pt-2 font-light">Cirno Fans Protection Association</p>
    </div>
    <ul class="flex justify-end">
      <li class="m-2">
        <router-link to="/projects">Projects</router-link>
      </li>
      <li class="m-2">
        <router-link to="/profile">Profile</router-link>
      </li>
      <li class="m-2">
        <router-link to="/about">About</router-link>
      </li>
    </ul>
  </nav>
</template>

<script lang="ts">
import { Vue, Options } from "vue-class-component";
@Options({})
export default class NavBar extends Vue {}
</script>
