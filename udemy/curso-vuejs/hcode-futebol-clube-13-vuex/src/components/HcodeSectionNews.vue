<template>
    
    <section>

        <div class="container">

            <HcodeSectionNewsIndividual
                v-for="notice in news"
                :key="notice.id"
                :img-name="notice.img"
                :img-info="notice.imgInfo"
                :news-date="notice.date"
            >
                
                <template #title>
                    <h2>{{ notice.title }}</h2>
                </template>
                
                <p>{{ notice.content | truncate(200) }}</p>

            </HcodeSectionNewsIndividual>

        </div>

    </section>

</template>

<script>
import HcodeSectionNewsIndividual from './HcodeSectionNewsIndividual'
import { mapGetters } from 'vuex'

export default {
    components: {
        HcodeSectionNewsIndividual
    },
    data() {
        return {
            
        }
    },
    computed: {
        ...mapGetters({
            news: 'getNews'
        })
    }
}
</script>

<style scoped>
section {
    padding: 50px 0;
    margin-top: 25px;
    background-color: #F37520;
}
</style>