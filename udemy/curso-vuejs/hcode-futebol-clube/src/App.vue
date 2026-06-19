<!-- app.vue -->

<template>
  <div class="app">
    <HcodeHeader/>
    <HCodeSection/>
    <HcodeFooter/>
  </div>
</template>


<script>
import HcodeHeader from './components/HcodeHeader.vue';
import HcodeFooter from './components/HcodeFooter.vue';
import HCodeSection from './components/HCodeSection.vue';

export default {
  name: 'App',
  components: {
    HcodeHeader,
    HCodeSection,
    HcodeFooter
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css?family=Rajdhani&display=swap')
</style>
