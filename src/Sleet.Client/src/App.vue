<template>
  <div id="nav">
    <p class="text-4xl">2134</p>
    <router-link to="/">Home</router-link> |
    <router-link to="/about">About</router-link>
    <NavBar />
  </div>

  <router-view />
</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>

<script lang="ts">
import NavBar from "@/components/NavBar.vue";
import { Options, Vue } from "vue-class-component";
@Options({
  component: NavBar,
})
export default class App extends Vue {}
</script>
