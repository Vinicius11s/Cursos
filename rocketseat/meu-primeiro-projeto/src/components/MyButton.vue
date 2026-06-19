<template>
    <button @click="$emit('update')">
        {{ title }}
    </button>
</template>

<script>
export default {
    name: 'MyButton',
    props: {
        title: {
            type: String,
            default: '+1'
        }
    }
}

</script>

<style scoped>
button {
    padding: 10px 20px;
    background-color: rgb(6, 136, 60);
    color: white;
    border: none;
    border-radius: 8px;
    cursor: pointer;
}

button:hover {
    background-color: #61e819;
}
</style>